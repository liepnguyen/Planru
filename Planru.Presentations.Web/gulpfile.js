var gulp = require('gulp');
var uglify = require('gulp-uglify');
var less = require('gulp-less');
var concat = require('gulp-concat');
var bowerFiles = require('main-bower-files');
var del = require('del');
var yargs = require('yargs').argv;
var minifyHTML = require('gulp-minify-html');

var paths = {
	scripts: ['src/**/*.js'],
	images: ''
};

gulp.task('clean', function(cb) {
  del(['build'], cb);
});

gulp.task('build:js', function () {
    if (yargs.release) {
    	gulp.src(paths.scripts)
    		//.pipe(concat('main.min.js'))
    		.pipe(uglify())
    		.pipe(gulp.dest('build'));
    }
    else {
    	gulp.src(paths.scripts)
    		.pipe(gulp.dest('build'));
    }
});

gulp.task('build:html', function() {
    if (yargs.release) {
        gulp.src(['src/**/*.html'])
            .pipe(minifyHTML({ comments: false, spare: false }))
            .pipe(gulp.dest('build'));
    }
    else {

    }
});

gulp.task('build:bower', function () {
    gulp.src(bowerFiles({}), { base: 'bower_components' })
		.pipe(gulp.dest('build/lib'));
});

gulp.task('default', ['build:js', 'build:html', 'build:bower']);