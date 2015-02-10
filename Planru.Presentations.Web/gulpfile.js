var gulp = require('gulp');
var uglify = require('gulp-uglify');
var less = require('gulp-less');
var concat = require('gulp-concat');
var bowerFiles = require('main-bower-files');
var del = require('del');
var yargs = require('yargs').argv;
var minifyHTML = require('gulp-minify-html');
var filter = require('gulp-filter');
var rename = require('gulp-rename');
var minifyCss = require('gulp-minify-css');
var inject = require('gulp-inject');

var paths = {
	scripts: ['src/**/*.js'],
	images: ''
};

gulp.task('clean', function(cb) {
  del(['build'], cb);
});

gulp.task('build:js', function () {
    if (yargs.release) {
    	gulp.src('src/**/*.js')
    		.pipe(uglify())
            .pipe(rename({ suffix: '.min' }))
    		.pipe(gulp.dest('build'));
    }
    else {
    	gulp.src('src/**/*.js')
    		.pipe(gulp.dest('build'));
    }
});

gulp.task('build:html', function() {
    var htmls = gulp.src(['src/**/*.html', '!src/index.html']);

    if (yargs.release) {
        htmls
            .pipe(minifyHTML({ comments: false, spare: false }));
    }

    htmls.pipe(gulp.dest('build'));
});

gulp.task('build:inject', function() {
    var index = gulp.src('./src/index.html');
    var services = gulp.src(['./src/**/*.service.js'], { read: false });
    var controllers = gulp.src(['./src/**/*.controller.js'], { read: false });
    var configs = gulp.src(['./src/**/*.config.js'], { read: false });

    if (yargs.release) {
        services.pipe(uglify()).pipe(rename({ suffix: '.min' }));
        controllers.pipe(uglify()).pipe(rename({ suffix: '.min' }));
        configs.pipe(uglify()).pipe(rename({ suffix: '.min' }));
    }

    index
        .pipe(inject(configs, { name: 'configs' }))
        .pipe(inject(services, { name: 'services' }))
        .pipe(inject(controllers, { name: 'controllers' }))
        .pipe(gulp.dest('./build'));
});

gulp.task('build:lib', function () {
    var index = gulp.src('./src/index.html');
    var jsFilter = filter('**/*.js');
    var cssFilter = filter('**/*.css');
    var components = gulp.src(bowerFiles(), { base: 'bower_components' })
        .pipe(jsFilter)
        .pipe(uglify())
        .pipe(rename({ suffix: '.min' }))
        .pipe(jsFilter.restore())
        .pipe(cssFilter)
        .pipe(minifyCss())
        .pipe(rename({ suffix: ".min" }))
        .pipe(cssFilter.restore())
		.pipe(gulp.dest('build/lib'));

    index.pipe(inject(components, { name: 'components' }))
        .pipe(gulp.dest('./build'));
});

gulp.task('default', ['clean'], function() {
    gulp.start('build:lib', 'build:html', "build:js", "build:inject");
});