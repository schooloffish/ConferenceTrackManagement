var webpack = require('webpack');
var HtmlWebpackPlugin = require('html-webpack-plugin');
var path = require('path');

module.exports = {
    context: path.join(__dirname, 'src'),
    devTools: "inline-sourcemap",
    entry: { 'app': './main.js' },
    module: {
        loaders: [
            {
                test: /\.js$/,
                exclude: /(node_modules|bower_components)/,
                loader: 'babel-loader',
                query: { presets: ['es2015', 'react'], plugins: ['transform-decorators-legacy', 'transform-class-properties'] }
            },
            { test: /\.css$/, loader: 'style-loader!css-loader' },
        ]
    },
    output: {
        filename: "[name].js",
        chunkFilename: '[id].chunk.js',
        path: path.join(__dirname, 'dist'),
    },
    plugins: [
        new webpack.optimize.DedupePlugin(),
        new webpack.optimize.OccurrenceOrderPlugin(),
        new webpack.optimize.UglifyJsPlugin({ mangle: false, sourceMap: false }),
        new webpack.optimize.CommonsChunkPlugin({
            name: ['app']
        }),
        new HtmlWebpackPlugin({ template: './index.html' })
    ]
};