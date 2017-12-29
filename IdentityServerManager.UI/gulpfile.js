/// <binding AfterBuild='copy:libs:dev' />
var gulp = require('gulp'),
    uglify = require('gulp-uglify'),
    concat = require('gulp-concat'),
    del = require('del'),
    sequence = require('run-sequence'),
    cssmin = require("gulp-cssmin"),
    jsPath = 'wwwroot/js',
    jsDist = jsPath + '/dist',
    cssPath = 'wwwroot/css',
    cssDist = cssPath + '/dist',
    libPath = 'wwwroot/lib',
    nodeModulesPath = 'node_modules';

var cssSourceFiles = [
    libPath + '/bootstrap/dist/css/bootstrap.min.css',
    cssPath + '/animate.min.css',
    cssPath + '/paper-dashboard.css',
    cssPath + '/themify-icons.css',
    nodeModulesPath + '/font-awesome/css/font-awesome.min.css',
    nodeModulesPath + '/bootstrap-dialog/dist/css/bootstrap-dialog.min.css',
    nodeModulesPath + '/select2/dist/css/select2.min.css',
];
var jsVendorSourceFiles = [
    libPath + '/jquery/dist/jquery.min.js',
    libPath + '/bootstrap/dist/js/bootstrap.min.js',
    jsPath + '/bootstrap-checkbox-radio.js',
    jsPath + '/bootstrap-notify.js',
    jsPath + '/paper-dashboard.js',
    nodeModulesPath + '/bootstrap-dialog/dist/js/bootstrap-dialog.min.js',
    nodeModulesPath + '/moment/moment.js',
    nodeModulesPath + '/select2/dist/js/select2.js',
];
var jsAppSourceFiles = [
    jsPath + '/site.js',
    //jsPath + '/backtotop.js',
    //jsPath + '/spin.js',
    //jsPath + '/utils.js',
    //jsPath + '/jquery.serializeObject.js',
];

gulp.task('clean', function () {
    return del(jsDist, { force: true });
});

gulp.task('copy:libs:dev', function (done) {
    sequence('clean', 'copy:app:dev', 'copy:vendor:dev', 'copy:vendor:css', done);
});

gulp.task('copy:libs:prod', function (done) {
    sequence('clean', 'copy:app:prod', 'copy:vendor:prod', 'copy:vendor:css', done);
});

gulp.task('copy:vendor:css', function () {
    return gulp.src(cssSourceFiles)
        .pipe(concat('styles.vendor.css'))
        .pipe(cssmin())
        .pipe(gulp.dest(cssDist));
});

gulp.task('copy:app:dev', function () {
    return gulp.src(jsAppSourceFiles)
        .pipe(concat('scripts.app.js'))
        .pipe(gulp.dest(jsDist));
});

gulp.task('copy:vendor:dev', function () {
    return gulp.src(jsVendorSourceFiles)
        .pipe(concat('scripts.vendor.js'))
        .pipe(gulp.dest(jsDist));
});

gulp.task('copy:app:prod', function () {
    return gulp.src(jsAppSourceFiles)
        .pipe(concat('scripts.app.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest(jsDist));
});

gulp.task('copy:vendor:prod', function () {
    return gulp.src(jsVendorSourceFiles)
        .pipe(concat('scripts.vendor.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest(jsDist));
});


