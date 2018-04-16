# UWOBookTrade
Agile Development Group Project

Currently testing on Pixel device. 
Theme is AppCompact.NoActionBar

Only adding this because I was making the same mistake, when setting sizes, use 'sp' (e.g. 35sp) for fonts and 'dp' (e.g. 100dp) for everything else (except for special values wrap_content and match_parent).

When adding views that require a default string (buttons, textviews, etc.) rather than hardcode the string, follow the Android convention of adding the desired string to the Resources/Values/Strings.xml file and then to use it, simply put @string/{name of string} in the text field.

To use the UWO image logo call it like this: @drawable/uwologo
