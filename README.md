# VersionIncrementer

I have placed ProductInfo.cs in the Data folder, it is picked up from there.

If running from VisualStudio in launchSettings.json change commandLineArgs to:
- "Feature"
- " \"Bug Fix\""

Or if you run from command line just provide those arguments.

Usually, layers (Application, Domain.. etc) are placed in separate projects. However, for simplicity, I placed them in folders. 

# Improvements
- Variable names could be improved
- Add custom exceptions, handling and throwing could be made better
- IncrementerService can be made more readable
- Path to ProductInfo can be picked up from config
- Use fluent validator, perhaps cover more cases (for example 1...2 will be treated as valid input which is incorrect)
- Make input reader more robust by making it case insensitive (currently it has to be exact match)
