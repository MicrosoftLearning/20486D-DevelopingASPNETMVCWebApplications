/// <binding ProjectOpened='sass-watcher, js-watcher' />
var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var sass = require('gulp-sass');
var cssmin = require('gulp-cssmin');
var watch = require('gulp-watch-sass');

var paths = {
    webroot: "./wwwroot/",
    nodeModules: "./node_modules/"
};

paths.jqueryjs = paths.nodeModules + "jquery/dist/jquery.js";
paths.destinationCssFolder = paths.webroot + "css/";
paths.destinationJsFolder = paths.webroot + "lib/";
paths.bootstrapCss = paths.nodeModules + "bootstrap/dist/css/bootstrap.css";
paths.bootstrapjs = paths.nodeModules + "bootstrap/dist/js/bootstrap.js";
paths.popperjs = paths.nodeModules + "popper.js/dist/umd/popper.js";
paths.vendorJsFileName = "vendor.min.js";
paths.vendorCssFileName = "vendor.min.css";
paths.vendorJsFiles = [paths.jqueryjs, paths.popperjs, paths.bootstrapjs];
paths.JsFiles = "./Scripts/*.js";
paths.JsFileName = "script.min.js";
paths.destinationMyJsFolder = paths.webroot + "script/";
paths.sassFiles = "./Styles/*.scss";
paths.compiledCssFileName = "main.min.css";

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
        .pipe(gulp.dest(paths.destinationMyJsFolder));
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

gulp.task("sass-watcher", function () {
    gulp.watch('./Styles/*.scss', ["min:scss"]);
});

gulp.task("js-watcher", function () {
    gulp.watch('./Scripts/*.js', ["min:js"]);
});

