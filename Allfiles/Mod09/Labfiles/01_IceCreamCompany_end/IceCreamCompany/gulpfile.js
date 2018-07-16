var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var watch = require('gulp-watch-sass');
var sass = require('gulp-sass');
var cssmin = require('gulp-cssmin');

var paths = {
    webroot: "./wwwroot/",
    nodeModules: "./node_modules/"
};

paths.jqueryjs = paths.nodeModules + "jquery/dist/jquery.js";
paths.popperjs = paths.nodeModules + "popper.js/dist/umd/popper.js";
paths.bootstrapjs = paths.nodeModules + "bootstrap/dist/js/bootstrap.js";
paths.vendorJsFiles = [paths.jqueryjs, paths.popperjs, paths.bootstrapjs];
paths.destinationJsFolder = paths.webroot + "lib/";
paths.vendorJsFileName = "vendor.min.js";
paths.JsFiles = "./Scripts/*.js";
paths.JsFileName = "script.min.js";
paths.destinationExistingJsFolder = paths.webroot + "script/";
paths.sassFiles = "./Styles/*.scss";
paths.compiledCssFileName = "main.min.css";
paths.destinationCssFolder = paths.webroot + "css/";
paths.bootstrapCss = paths.nodeModules + "bootstrap/dist/css/bootstrap.css";
paths.vendorCssFileName = "vendor.min.css";

gulp.task("copy-js-file", function () {
    return gulp.src(paths.jqueryjs)
        .pipe(gulp.dest(paths.destinationJsFolder));
});
 
gulp.task("min-vendor:js", function () {
    return gulp.src(paths.vendorJsFiles)
        .pipe(concat(paths.vendorJsFileName))
        .pipe(uglify())
        .pipe(gulp.dest(paths.destinationJsFolder));
});

gulp.task("min:js", function () {
    return gulp.src(paths.JsFiles)
        .pipe(concat(paths.JsFileName))
        .pipe(uglify())
        .pipe(gulp.dest(paths.destinationExistingJsFolder));
});

gulp.task("min:scss", function () {
    return gulp.src(paths.sassFiles)
        .pipe(sass().on('error', sass.logError))
        .pipe(concat(paths.compiledCssFileName))
        .pipe(cssmin())
        .pipe(gulp.dest(paths.destinationCssFolder));
});

gulp.task("min-vendor:css", function () {
    return gulp.src(paths.bootstrapCss)
        .pipe(concat(paths.vendorCssFileName))
        .pipe(cssmin())
        .pipe(gulp.dest(paths.destinationCssFolder));
});

gulp.task("js-watcher", function () {
    gulp.watch('./Scripts/*.js', ["min:js"]);
});

gulp.task("sass-watcher", function () {
    gulp.watch('./Styles/*.scss', ["min:scss"]);
});



