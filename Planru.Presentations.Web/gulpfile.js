var gulp = require('gulp');
var uglify = require('gulp-uglify');
var less = require('gulp-less');
var concat = require('gulp-concat');

gulp.task('default', function () {
    
});

gulp.task('minifyJs', function () {
    gulp.src('src/**/.js')
  		.pipe(uglify({
  		    outSourceMap: true
  		}))
  		.pipe(gulp.dest('dist'));
});