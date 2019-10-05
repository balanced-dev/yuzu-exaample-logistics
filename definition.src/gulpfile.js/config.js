const prettyjson = require('prettyjson');

var projectName = 'Logistics';	

base = {
	devRoot: './_dev',
	devSource: './_dev/_source',
	devCompiled: './_dev/_client',
	devTemplates: './_dev/_templates',
	distRoot: '../delivery.src/'+ projectName,
	distClient: '../delivery.src/'+ projectName + '/_client',
	distTemplates: '../delivery.src/'+ projectName + '/_templates',
};

paths = {	
	fonts: {
		src: base.devSource + '/fonts',
		dest: base.devCompiled + '/fonts/',
		dist: base.distClient + '/fonts/'
	},
	handlebars: {
		data: {
			layout: base.devTemplates + '/src/_layouts/',
			templates: base.devTemplates + '/data/',
			dist: base.distTemplates + '/data/'
		},
		layout: {
			src: base.devTemplates + '/layouts/'
		},
		blocks: {
			src: base.devTemplates + '/src/blocks/'
		},
		pages: {
			src: base.devTemplates + '/src/',
			dest: base.devTemplates + '/html/',
			dist: base.distTemplates
		},
		paths: {
			dist: base.distTemplates + '/paths/'
		},
		schema: {
			dist: base.distTemplates + '/schema/'
		},
		xml: {
			dest: base.devTemplates
		}
	},
	images: {
		src: base.devSource + '/images/',
		dest: base.devCompiled + '/images/',
		dist: base.distClient + '/images/'
	},
	js: {
		src: base.devSource + '/js',
		dest: base.devCompiled + '/js/',
		dist: base.distClient + '/js/'
	},
	styles: {
		src: base.devSource + '/styles',
		dest: base.devCompiled + '/styles/',
		dist: base.distClient + '/styles/'
	},
	libraryStyles: {
		src: base.devSource + '/css',
		dest: base.devCompiled + '/css/',
		dist: base.distClient + '/css/'
	}
};

files = {
	styles: paths.styles.src + '/style.scss',
	stylesBackOffice: paths.styles.src + '/backoffice.scss',
	libraryStyles: paths.libraryStyles.src + '/**/*.css',
	stylesheets: paths.styles.dest + '/*.css',
	css: paths.styles.dest + '/style.css',
	cssDist: paths.styles.dist + '/style.css',
	images: paths.images.src + '/**/*',
	fonts: paths.fonts.src + '/**/*',
	html: paths.handlebars.pages.dest + '/**/*.html',
	js: paths.js.src + '/**/*.js',
	templateLayoutData: paths.handlebars.data.layout + 'layout.json',
	templateLayouts: paths.handlebars.layout.src,
	templateData: paths.handlebars.data.templates,
	templatePartials: paths.handlebars.blocks.src,
	templatePages: paths.handlebars.pages.src,
	templateHTML: paths.handlebars.pages.dest,
	templateXML: paths.handlebars.xml.dest,
};

/*  Display files ouput */
var showPaths = (done) => {

	var options = {
		keysColor: 'green',
		dashColor: 'red',
		stringColor: 'white',
		indent: 4
	}

	console.log('Base');
	console.log(prettyjson.render(base, options));
	console.log('Paths');
	console.log(prettyjson.render(paths, options));
	console.log('Files');
	console.log(prettyjson.render(files, options));

	done();
};

exports.base = base;
exports.paths = paths;
exports.files = files;
exports.showPaths = showPaths;
