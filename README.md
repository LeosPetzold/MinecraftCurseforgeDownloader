# Usage
Simply select your mods folder (Windows: "%appdata%/.minecraft/mods"), your profile folder and fill in your CurseForge API key, which you can obtain in the [CurseForge for Studios](https://console.curseforge.com/#/api-keys) developer console after creating a CurseForge account.
This Windows Forms application only downloads mods from manifest.json inside the .zip profile files, meaning that any manually added mods will not be copied over.

# Features and issues
- Downloading Minecraft mods from the CurseForge database using the .zip profile file.
- [PLANNED] Automatically copying over override mods.

This project has no real client-side error handling at the moment, if you choose an invalid profile file then it may fail with a thrown Exception.
For some reason CurseForge API isn't that redundant, so there is a system for retrying any failed to download mods.
If there is any problem then open up an issue and I'll probably get to it.
The code doesn't check whether the mod file already exists in your selected mod folder.

- The top (first) progressbar shows the total number of mods downloaded.
- The bottom (second) progressbar shows the number of mods fetched during the first iteration of mod fetching.

# Help
### HTTP Forbitten (403)
This is the error you get if you supply an invalid API key or CurseForge is updating/shutting down their interface. Example:
![Invalid API error: HTTP 403 Forbitten](https://github.com/user-attachments/assets/aba261dc-17e2-459e-a7a2-1b658ad4bdb6)

In order to fix this go to the [CurseForge for Studios](https://console.curseforge.com/#/api-keys) developer console and copy your correct API key, if it doesn't work then regenerate it or check if CurseForge hasn't suspended your account from contacting this service of theirs (if that can even happen). Then supply the key to the application which will then try its best to fulfill all of your downloading needs.

# Notes:
This app only supports Minecraft.
I have yet to even test if the downloaded mods are usable.
Cheers :)
PS: I hope that I'm not breaking any law.

---
As long as this repository is under my control this project will never collect any data about your system (except the stuff that .NET needs - but that is not from my side), your profile files, your API key(s) or any other thing such as that.
This repository should not have any interaction with the Internet other than communicating with the CurseForge API and downloading mods from the URLs supplied by the interface.
