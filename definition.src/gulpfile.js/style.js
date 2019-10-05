const gulp = require('gulp'); 
const paths = require('./config').paths; 
const files = require('./config').files; 
const server = require('./browser-sync'); 

// Clean all partials from temp dir
// const cleanStylePartials = () => {

//     return $.del([ paths.styles.partials + '/*.scss' ]);
// };

// Copy all the partial sass files from block directories and put in style dir
// const loadStylePartials = () => {

//     return gulp.src(files.partialscss)
//         .pipe($.flatten())
//         .pipe(gulp.dest(paths.styles.partials));
// };

// Copy library stylesheets
const libStyles = (done) => {
    
  gulp.src(files.libraryStyles)
      .pipe(gulp.dest(paths.libraryStyles.dest));

  done();
};

// Build Scss Style
const buildStyle = () => {
    
    return gulp.src(files.styles)
      .pipe($.sourcemaps.init())
      .pipe($.sassBulkImport())
      .pipe($.sass().on('error', $.sass.logError))
      .pipe($.autoprefixer())
      .pipe($.sourcemaps.write('./'))
      .pipe(gulp.dest(paths.styles.dest));
};

// Build Scss Style
const buildBackOfficeStyles = () => {
    
  return gulp.src(files.stylesBackOffice)
    .pipe($.sassBulkImport())
    .pipe($.sass().on('error', $.sass.logError))
    .pipe($.autoprefixer())
    .pipe(gulp.dest(paths.styles.dest));
};

const run = gulp.series(/*cleanStylePartials, loadStylePartials,*/ buildStyle, buildBackOfficeStyles, libStyles);

exports.run = run;
exports.reload = gulp.series(run, server.reload);