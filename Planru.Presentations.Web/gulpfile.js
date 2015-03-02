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
var runSequence = require('gulp-run-sequence');
var ignore = require('gulp-ignore');
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

gulp.task('build:css', function() {
    var css = gulp.src('src/content/css/**/*.*');
    if (yargs.buildProd) {
        // TODO: should be implemented to minify all css files in build pro mode
    }
    return css.pipe(gulp.dest('build/content/css'));
});

gulp.task('build:images', function() {
    var css = gulp.src('src/content/images/**/*.*');
    if (yargs.buildProd) {
        // TODO: should be implemented to compress all image files in build pro mode
    }
    return css.pipe(gulp.dest('build/content/images'));
});

gulp.task('build:fonts', function() {
    var css = gulp.src('src/content/fonts/**/*.*');
    return css.pipe(gulp.dest('build/content/fonts'));
});

gulp.task('build:html', function() {
    var htmls = gulp.src(['src/**/*.html', '!src/index.html']);
    if (yargs.buildProd) {
        htmls.pipe(minifyHTML({ comments: false, spare: false }));
    }
    return htmls.pipe(gulp.dest('build'));
});

gulp.task('build:index', function() {
    var index = gulp.src('./src/index.html');
    var importantsFilter = [
        '**/jquery.min.js'
    ]

    var scripts = gulp.src('./build/scripts/**', { read: false });
    var bowerFiles = gulp.src([
        './build/lib/**/*.js', 
        './build/lib/**/*.css'], { read: false });
    var components = bowerFiles.pipe(ignore.exclude(importantsFilter));
    var importants = bowerFiles.pipe(filter(importantsFilter));
    var services = gulp.src(['./build/app/**/*.service.js'], { read: false });
    var controllers = gulp.src(['./build/app/**/*.controller.js'], { read: false });
    var configs = gulp.src(['./build/app/**/*.config.js'], { read: false });
    var events = gulp.src(['./build/app/**/*.events.js'], { read: false });

    var transform = function (filepath) {
        arguments[0] = filepath.replace('/build/', './');
        return inject.transform.apply(inject.transform, arguments);
    };

    return index.pipe(inject(components, { name: 'components', transform: transform }))
        .pipe(inject(importants, { name: 'importants', transform: transform }))
        .pipe(inject(scripts, { name: 'scripts', transform: transform }))
        .pipe(inject(services, { name: 'services', transform: transform }))
        .pipe(inject(controllers, { name: 'controllers', transform: transform }))
        .pipe(inject(configs, { name: 'configs', transform: transform }))
        .pipe(inject(events, { name: 'events', transform: transform }))
        .pipe(gulp.dest('./build'));
});

gulp.task('build:bower', function () {
    var jsFilter = filter('**/*.js');
    var cssFilter = filter('**/*.css');
    return gulp.src(bowerFiles(), { base: 'bower_components' })
        .pipe(jsFilter)
        .pipe(uglify())
        .pipe(rename({ suffix: '.min' }))
        .pipe(jsFilter.restore())
        .pipe(cssFilter)
        .pipe(minifyCss())
        .pipe(rename({ suffix: '.min' }))
        .pipe(cssFilter.restore())
		.pipe(gulp.dest('build/lib'));
});

gulp.task('default', ['build'], function () {
    
});

gulp.task('build', function (cb) {
    runSequence(
        'clean', 
        ['build:bower', 
        'build:html', 
        'build:js', 
        'build:css', 
        'build:fonts', 
        'build:images'], 
        'build:index', cb);
});