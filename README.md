# DBD_ModInstaller
This repository was made for educational purposes only, do not use implemented here features in actual game!


**MOD PACKAGE TEMPLATE:**
```json
[
  {
    "modtitle": "",
    "sourcefile": "",
    "original": "",
    "changed": ""
  },
  {
    "modtitle": "MOD_2",
    "sourcefile": "",
    "original": "",
    "changed": ""
  }
]
```
It's possible to put any amount of mods in to 1 json file, program will parse all of them. Just don't forget that .pak editing limit is 2-3 textures!


**EXAMPLE OF MOD PACKAGE:**
```json
[
  {
    "modtitle": "Super Popular Mod",
    "sourcefile": "pakchunk5-WindowsNoEditor.pak",
    "original": "65 72 2F 41 49 43 6F .. .. ...",
    "changed": "00 00 2F 53 63 72 69 .. .. ..."
  }
]
```

Keep in Mind that this repository & program was just a concept + it doesn't work with .pak files, which size is over 4GB (buffer being overloaded), feel free to make the program better! If you're not part of MBD community & have better version of my code, please, come to https://discord.gg/n2SBfWXJhN & PM Кранч 「🐺」#6585 (me) / Schinsly
