/// <binding BeforeBuild='debugbuild' />
/*
  This file in the main entry point for defining grunt tasks and using grunt plugins.
  Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
"use strict";

module.exports = function (grunt) {
    grunt.loadNpmTasks('grunt-contrib-copy');
    require('load-grunt-tasks')(grunt);

    grunt.initConfig({
        copy: {
            main: {
                files: [
                  // includes files within path
                  { expand: true, src: ['*.html'], dest: 'wwwroot/', filter: 'isFile' },
                ],
            },
        },
        babel: {
            options: {
                sourceMap: true,
                presets: ['react']
            },
            dist: {
                files: {
                    'wwwroot/hello.js': 'hello.jsx'
                }
            }
        }        
    });
    
    grunt.registerTask('debugbuild', [
		'copy', 'babel'
    ]);
    
};
