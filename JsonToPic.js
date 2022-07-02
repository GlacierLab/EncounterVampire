console.log("Vampire Engine-Qinlili 2022");
const fs = require('fs');
const path = require("path");
const timelog = text => { console.log(new Date().toLocaleTimeString() + "  -  " + text) };
timelog("Initializing Vampire Engine...");
if (process.argv[2]) {
    timelog("JSON path:" + process.argv[2]);
} else {
    console.error("ERROR:No Path Provided!");
    process.exit()
};
timelog("Reading JSON...")
let rawdata = fs.readFileSync(process.argv[2]);
timelog("JSON size:" + rawdata.length);
timelog("Parsing JSON...");
let pics = JSON.parse(rawdata);
timelog("Parse Success, " + pics.length + " Images Found.");
let foldername = path.basename(process.argv[2]);
foldername = foldername.substring(0, foldername.indexOf("."));
timelog("Making Folder: " + foldername);
if (!fs.existsSync(foldername)) {
    fs.mkdirSync(foldername);
};
for (let i = 0; pics[i]; i++) {
    timelog("Saving Image " + i + "...");
    timelog("File Name: " + pics[i].name);
    fs.writeFile(foldername + "/" + pics[i].name + ".png", pics[i].value, 'base64', function (err) {
        console.log("Successfully Write" + pics[i].name + ".png.");
    });
};
timelog("Success!");
