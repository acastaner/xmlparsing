# xmlparsing
Small program to reproduce a bug I'm running into.

When this program is executed in .NET 4.51 profile, it will crash in one of the XML responses from the MusicBrainz API. The other response doesn't crash. When using the CoreCLR profile, none of them crash.

I'm the maintainer of the library this code uses to query the MusicBrainz API (here: https://github.com/ribandelle/MusicBrainz.DNX) and I found this during development.
