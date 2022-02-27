# Journal Manager
This is a Windows Forms application that allows the user to write journal entries, save them locally, and view them later. 
I made this out of a desire to find a better way to keep a journal, preferring to type instead of physically write, while being able to use such an application offline.

## Setting Up
Upon opening the program for the first time, you'll be greeted with a window that looks like this:

![Journal_Manager_5vZXjTHnf0](https://user-images.githubusercontent.com/58154576/155890117-6190934e-c5df-4608-bf19-b78e9873d0cc.png)

Select the directory you'd like the program to read journal entries from. This is also the location where the program quicksaves journal entries you write (more info below).

That done, you'll now be presented with the main menu:

![Journal_Manager_wDhgPA7oOD](https://user-images.githubusercontent.com/58154576/155890452-769e3ba2-e823-425f-b424-368fa353adad.png)

## Creating an Entry
Click on "New Entry" and you'll be presented with this window:

![Journal_Manager_iP6I2M6nnh](https://user-images.githubusercontent.com/58154576/155890458-6facb6bd-9295-49ae-8a22-33dcebb14998.png)

Here, you can write your entry in the contents box, and optionally add in a title for the entry. If filled in, this is what will be listed as the entry's title on the Entry Viewer;
it otherwise defaults the the entry's creation date and time. Optionally, you can also set the background color of the entry to one of a few pre-defined colors.

**You can also format text!** In order to do that, you can use the following tags:
- Surround text in [b] and [/b] to make the enclosed text **bold.**
- Surround text in [i] and [/i] to make the enclosed text *italic.*
- Surround text in [u] and [/u] to make the enclosed text underlined.
- There are three header tags, [h1], [h2], and [h3] that can make bigger text.
- You can also combine tags! (e.g. to make bold, italicized text)

On the top bar, you can load an existing entry to edit, but note that this will discard any unsaved changes you've made to whatever entry you are currently editing.

Here's an example entry of mine that I'll refer to later:
![image](https://user-images.githubusercontent.com/58154576/155890711-85c9c81f-ac6b-45df-88b7-00dd8f065e3a.png)

## Saving an Entry
Once you're done with your entry, you can save it in one of two ways:
- Pressing "Save" on the top left will do a quicksave of the entry, saving the entry in the directory you specified earlier, with its name being based on the system date and time: 
- ![image](https://user-images.githubusercontent.com/58154576/155890730-c7bba409-bcd1-4dc4-b78b-223ed69aefed.png)
- "Save As" will allow you to save the entry as a custom name, or overwrite an already existing entry.

## Viewing Previous Entries
Back at the main menu, go to "View Entries." This will bring you to a list of entires you've already made, listed by their title (if none supplied, the title used is the date/time 
the entry was created) and with the entry's color as a background:

![image](https://user-images.githubusercontent.com/58154576/155890825-98603774-1032-4113-9b46-d61f6de67bfe.png)

Here, you can simply view the entry (without editing it), or you can bring the entry's contents into the entry editor and modify it. Double-clicking an entry's name in the list
will bring you to the entry viewer:

![image](https://user-images.githubusercontent.com/58154576/155890873-73976d93-34e7-4f1e-ac90-ae792a022ac2.png)

You can also see the previous and next entries easily, if applicable, by pressing the two buttons on the bottom left/right.

## Preferences

Here, you can change the journal directory and font:

![image](https://user-images.githubusercontent.com/58154576/155890912-2d6e6046-0e45-4b16-9444-f5669b728e46.png)

The journal directory takes in a folder, while the font option brings you to the font selector. You can change the typeface, as well as the font size. The size will adjust the
size of normal text and headers (which are relative to the normal text size) accordingly.

![image](https://user-images.githubusercontent.com/58154576/155890958-6ce9b148-287b-41c6-979b-3da4eaffabd0.png)
![image](https://user-images.githubusercontent.com/58154576/155890966-a8ebd0fa-722c-41ca-a932-4b8af269a122.png)

## Closing Words

I hope you enjoy and/or get use out of this project! If you have any feedback, don't hesistate to toss something in the issues section.







