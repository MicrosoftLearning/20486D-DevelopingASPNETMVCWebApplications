var gulp = require('gulp');
var concat = require("gulp-concat");
var uglify = require("gulp-uglify");
var sass = require('gulp-sass');
var cssmin = require("gulp-cssmin");

var paths = {
    webroot: "./wwwroot/",
    nodeModules: "./node_modules/"
};

paths.jqueryjs = paths.nodeModules + "jquery/dist/jquery.js";
paths.destinationCssFolder = paths.webroot + "css/";
paths.destinationJsFolder = paths.webroot + "lib/";

paths.bootstrapCss = paths.nodeModules + "bootstrap/dist/css/bootstrap.css";
paths.bootstrapjs = paths.nodeModules + "bootstrap/dist/js/bootstrap.js";
paths.vendorJsFileName = "vendor.min.js";
paths.vendorCssFileName = "vendor.min.css";
paths.vendorJsFiles = [paths.bootstrapjs, paths.jqueryjs];

//exercise 2 task 1
paths.sassFiles = "./Styles/*.scss";
paths.compiledCssFileName = "main.min.css";


//exercise 1 task 2 
gulp.task("copy-js-file", function () {
    return gulp.src(paths.jqueryjs)
        .pipe(gulp.dest(paths.destinationJsFolder));
});

//exercise 1 task 4
gulp.task("min:js", function () {
    return gulp.src(paths.vendorJsFiles)
        .pipe(concat(paths.vendorJsFileName))
        .pipe(uglify())
        .pipe(gulp.dest(paths.destinationJsFolder));
});


//exercise 2 task 1
gulp.task("min:scss", function () {
    return gulp.src(paths.sassFiles)
        .pipe(sass().on('error', sass.logError))
        .pipe(concat(paths.compiledCssFileName))
        .pipe(cssmin())
        .pipe(gulp.dest(paths.destinationCssFolder));
});

//exercise 3 task 3
gulp.task("min-vendor:css", function () {
    return gulp.src(paths.bootstrapCss)
        .pipe(concat(paths.vendorCssFileName))
        .pipe(cssmin())
        .pipe(gulp.dest(paths.destinationCssFolder));
});

//exercise 1 task 5
gulp.task("js-watcher", function () {
    gulp.watch(paths.vendorJsFiles, ["min:js"]);
});

gulp.task("sass-watcher", function () {
    gulp.watch(paths.sassFiles, ["min:scss"]);
});

gulp.task("css-watcher", function () {
    gulp.watch(paths.sassFiles, ["min-vendor:css"]);
});