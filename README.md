# VersionIncrementer

In launchSettings.json change commandLineArgs to:
- "Feature"
- " \"Bug Fix\""

Usually, layers (Application, Domain.. etc) are placed in separate projects. However, for simplicity, I placed them in folders. 

# Improvements
- Add custom exceptions, handling and throwing could be made better
- IncrementerService can be made more readable
- Path to ProductInfo can be picked up from config
- Use fluent validator, perhaps cover more cases
