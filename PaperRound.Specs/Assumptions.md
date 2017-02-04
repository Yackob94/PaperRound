# Assumptions
### Houses on a particular side of a street are not directly next to each other.  
For example:  
1 3 5 7 9 2 4 6 8  
```  
H H H H H  
          H H H H
```
1 3 2 4 5 7 9 6 8  
```  
H H     H H H  
    H H       H H
```

### Numbers must always be ascending
Valid  
1 3 5 7 2 4 6

Not Valid  
1 5 3 7 2 4 6

### Numbers must be on a single line
Any file with a line count > 1 will be marked as invalid