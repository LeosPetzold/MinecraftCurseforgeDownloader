# Usage
Simply select your mods folder (Windows: "%appdata%/.minecraft/mods"), your profile folder and fill in your CurseForge API key, which you can obtain [here](https://console.curseforge.com/#/api-keys) after creating a CurseForge account.
This Windows Forms application only downloads mods from manifest.json inside the .zip profile files, meaning that any manually added mods will not be copied over.

# Features and issues
- Downloading Minecraft mods from the CurseForge database using the .zip profile file.
- [PLANNED] Automatically copying over override mods.

This project has no real client-side error handling at the moment, if you choose an invalid profile file then it may fail with a thrown Exception.
For some reason CurseForge API isn't that redundant, so there is a system for retrying any failed to download mods.
If there is any problem then open up an issue and I'll probably get to it.
The code doesn't check whether the mod file already exists in your selected mod folder.

# Notes:
This app only supports Minecraft.
I have yet to even test if the downloaded mods are usable.
Cheers :)
PS: I hope that I'm not breaking any law.
