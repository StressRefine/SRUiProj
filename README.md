# SRUiProj
 Prothect to create the executable for SRui.
 
 Windows Visual Studio version that was last modified using VS2013.
 That and any newer version should work to compile this project.
 It is in C#. Doubleclick on the ".sln" file to open the project.
 If using a newer version than 2013, you may get a message about updating to the latest VS version, to which you should say yes.
 Choose a configuration at the top (debug or release).
 Now hit build to compile. A subfolder is created bin/debug or bin/release depending on the configuration. Inside that folder
 will be the executable SRui.exe
 
 Note: there is no linux version of SRui because it is written C#, which is windows-specifice. It would be relatviely simple to recreate 
 it in a portable language like Java, to which C# is quite similar.
 To run stressRefine under linux without a UI I recommend the following:
 1. Place the executable bdfTranslate.exe, and whichever engine executable you are using (the simpler one in SRwithMklProj or the full version in fullEngine) in a working folder.
 That folder must contain 2 files translateCmd.txt, and ModelFileName.txt.
 TranslateCmd.txt contains 2 lines:
 1. The full path to the nastran input file (.bdf or .dat) to be translated
 2. The full path to th folder that will contain the .msh input file for the stressRefine engine
 Modefilename contains a single line which is the path to the input folder, the same as line 2 above.
 run BdfTranslate to create the .msh input file, then run SRwithMkl.exe to solve.
 The BdfTranslate step can be skipped if you are rerunning a previously created .msh file.
 This is using default settings. To modify the default settings there must exist an additional file with extension .srs in the input
 folder. I've posted a file engineSettings.txt in this repository which has the spec for the settings
 There is an additional step for breakout models.
 The executable is first run with the line savebreakout in the .srs file.
 For example the model name might be bridge. 
 This will create a new folder bridge_breakout, to it, which contains the extracted breakout model.
 ModelFileName.txt must now be changed to point to bridge_breakout to solve the bridge model
 
 
