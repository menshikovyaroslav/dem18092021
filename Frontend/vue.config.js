const path = require('path');

module.exports = {
  configureWebpack: {
		resolve: {
			extensions: ['.js', '.vue', '.ts'],
			alias: {
				'@': path.join(__dirname, '/src'),
				'@api': path.join(__dirname, '/src/middleware/api'),
				'@assets': path.join(__dirname, '/src/assets'),
				'@components': path.join(__dirname, '/src/components'),
				'@plugins': path.join(__dirname, '/src/middleware/plugins'),
				'@router': path.join(__dirname, '/src/router'),
				'@store': path.join(__dirname, '/src/store'),
				'@utils': path.join(__dirname, '/src/middleware/utils'),
				'@views': path.join(__dirname, '/src/views'),
			},
		},
	},
  transpileDependencies: [
    'vuetify'
  ]
}
