# name-sorter
This program sorts a list of given names from a txt file. It sorts it by last name first then by given names a person may have (1-3 names separated by whitespace). It will then output the sorted names into the console output and to a txt file. 

## Usage 
`name-sorter ./<file path of unsorted list>`

## Compile and Run

1. Download the code and open a terminal window at the project's root directory. 
2. Go to the folder NameSorter `cd NameSorter`
3. Compile with `csc *.cs`
4. Run the executable file with the argument of the file path for the unsorted list.  In Mac terminal: `mono name-sorter.exe ./unsorted-names-list.txt`
5. A list of sorted names will appear on your terminal window and also in the file *sorted-names-list.txt* in the current directory.
