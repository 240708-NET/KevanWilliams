# Target and Compiler Options

Compiler options are used to change the compiler’s default operation. The compiler options needed to compile the project along with the root files are defined by the **tsconfig.json** file. The "compilerOptions" property can be omitted, in which case the compiler’s defaults are used.

## Target

The target option specifies the version of JavaScript the TypeScript compiler should transpile your code into. By default, it’s set to ES3, but you can adjust it to match your target environment. For instance, if you’re deploying to older environments, setting it to ES5 ensures compatibility.

Default:
- ES3
Allowed:
- es3
- es5
- es6/es2015
- es2016
- es2017
- es2018
- es2019
- es2020
- es2021
- es2022
- es2023
- esnext


## Example Configuration

```sh
{
  "compilerOptions": {
    "target": "es5",
    "module": "commonjs",
    "sourceMap": true,
    "outDir": "out",
    "noImplicitAny": true,
  }
}
```


**`Target`**: The target option specifies the version of JavaScript the TypeScript compiler should transpile your code into. By default, it’s set to ES3, but you can adjust it to match your target environment. For instance, if you’re deploying to older environments, setting it to ES5 ensures compatibility.

**`Module`**: The module option determines the module system you’re using, such as CommonJS, AMD, or ES6 modules. It impacts how your compiled TypeScript code interacts with local files and node_modules.

**`SourceMap`**: When sourceMap is set to true, TypeScript generates source maps, which allow you to debug your TypeScript code even after compilation.

**`OutDir`**: The outDir option specifies the directory where the compiled JavaScript files will be placed.

**`NoImplicitAny`**: Turning on noImplicitAny however TypeScript will issue an error whenever it would have inferred any







