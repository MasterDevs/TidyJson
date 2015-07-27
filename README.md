# TidyJson [![Build status](https://ci.appveyor.com/api/projects/status/7pfj1a3n0c8k51yv/branch/master?svg=true)](https://ci.appveyor.com/project/jquintus/tidyjson/branch/master) [![Chocolatey](https://img.shields.io/chocolatey/dt/scriptcs.svg?style=flat-square)](https://chocolatey.org/packages/TidyJson.portable) [![Chocolatey](https://img.shields.io/chocolatey/v/git.svg?style=flat-square)](https://chocolatey.org/packages/TidyJson.portable)

Windows command line app to pretty print JSON 

# Installation
TidyJson can be installed with [Chocolatey](https://chocolatey.org/)

    choco install tidyjson.portable

# Usage
    Usage: tidyJson [OPTIONS]
    Uses standard in and standard out if input or output not supplied

      -c, --clipboard    Read JSON from clipboard and write it back to the
                         clipboard
      -i, --inputFile    JSON input file
      -o, --output       Output file
      -v, --verbose      Include detailed information in the output

    Examples:
        echo {json:'value'} | tidyJson
            Read JSON from standard input and write it to standard output

        tidyJson -c
            Read JSON from clipboard and write it back to the clipboard

        tidyJson -f myOutput.json
            Read JSON from standard input and write it to the file myOutput.json

        tidyJson -i myInput.json
            Read JSON from the file myInput.Json and write it to standard output

        tidyJson -i myInput.json -f myOutput.json
            Read JSON from the file myInput.Json and write it to the file myOutput.json

# Credits

TidyJson uses 

* MasterDev's [ChocolateyCoolWhip](https://github.com/MasterDevs/ChocolateyCoolWhip) to build and deploy to Chocolatey
* [MasterDevs.Clippy](https://github.com/MasterDevs/Clippy) to read and write to the clipbord
* [Json.Net](http://www.newtonsoft.com/json) to format JSON