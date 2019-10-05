const gulp = require('gulp');
const paths = require('./config').paths;
const files = require('./config').files;
const server = require('./browser-sync');

const scripts = (done) => {

    gulp.src(files.js)
        .pipe(gulp.dest(paths.js.dest));
    done();
};

const run = gulp.series(scripts);

exports.run = run;
exports.reload = gulp.series(run, server.reload);