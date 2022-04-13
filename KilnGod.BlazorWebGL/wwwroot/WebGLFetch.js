'use strict';

// need to export these to make them strict by default.

class FileContents {
    constructor(fileName, alias) {
        this.fileName = fileName;
        this.alias = alias;
        this.jsonObject = null;
        this.text = null;
    }

    
}

class FileManager {
    constructor(webgl) {
        this.webgl = webgl;
    }

    fetchJson(fileURL, alias = 'default') {
        return fetch(fileURL, {headers: {
            'Content-Type': 'application/json;charset=utf-8'
        }})
            .then(response => response.json())
            .then(object => {
                object.alias = alias || object.alias;
                const fileContents = new FileContents(fileURL, alias);
                object.visible = true;
                this.webgl.fileStorage[object.alias] = fileContents;
                
            })
            .catch((err) => {
                errmsg = err; console.error(errmsg, ...arguments)
            });
    }

    fetchText(fileURL, alias) {
        return fetch(fileURL, {
            headers: {
                'Content-Type': 'text/plain'
            }
        })
            .then(r => {
                if (!r.ok) {
                    throw new Error("http error " + r.statusText);
                }

                return r.text();
            })
            .then(t => {
                const fileContents = new FileContents(fileURL, alias);
                
                fileContents.text = t;
                this.webgl.fileStorage[alias] = fileContents;
            })
            .catch((err) => {
                errmsg = err; console.error(errmsg, ...arguments)
            });
    }
}
