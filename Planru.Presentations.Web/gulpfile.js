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
var clean = require('gulp-clean');
var when = require('when');

gulp.task('clean', function () {
    return gulp.src('build', { read: false })
        .pipe(clean());
});

gulp.task('build:js', function () {
    var scripts = gulp.src('src/**/*.js');
    if (yargs.buildProd) {
    	scripts.pipe(uglify()).pipe(rename({ suffix: '.min' }));
    }
    return scripts.pipe(gulp.dest('build'));
});

gulp.task('build:html', function() {
    var htmls = gulp.src(['src/**/*.html', '!src/index.html']);
    if (yargs.buildProd) {
        htmls.pipe(minifyHTML({ comments: false, spare: false }));
    }
    return htmls.pipe(gulp.dest('build'));
});

gulp.task('build:index', ['build:bower', 'build:js'], function() {
    var index = gulp.src('./src/index.html');
    var components = gulp.src(['./build/lib/**/*.js', './build/lib/**/*.css'], { read: false });

    var services = gulp.src(['./build/app/**/*.service.js'], { read: false });
    var controllers = gulp.src(['./build/app/**/*.controller.js'], { read: false });
    var configs = gulp.src(['./build/app/**/*.config.js'], { read: false });

    var transform = function (filepath) {
        arguments[0] = filepath.replace('/build/', './');
        return inject.transform.apply(inject.transform, arguments);
    };

    return index.pipe(inject(components, { name: 'components', transform: transform }))
        .pipe(inject(services, { name: 'services', transform: transform }))
        .pipe(inject(controllers, { name: 'controllers', transform: transform }))
        .pipe(inject(configs, { name: 'configs', transform: transform }))
        .pipe(gulp.dest('./build'));
});

gulp.task('build:bower', function () {
    var jsFilter = filter('**/*.js');
    var cssFilter = filter('**/*.css');
    return gulp.src(bowerFiles(), { base: 'bower_components' })
        .pipe(rename({ suffix: '.min' }))
        .pipe(jsFilter)
        .pipe(uglify())
        .pipe(jsFilter.restore())
        .pipe(cssFilter)
        .pipe(minifyCss())
        .pipe(cssFilter.restore())
		.pipe(gulp.dest('build/lib'));
});

gulp.task('default', ['build'], function () {

});

gulp.task('build', ['clean'], function () {
    var d = when.defer();
    gulp.start(['build:index'], function () {
        d.resolve();
    });
    return d.promise;
});