#!/usr/bin/env python3

# Given: A DNA string s of length at most 1000 bp.
#
# Return: Four integers (separated by spaces) representing 
# the respective number of times that the symbols 'A', 'C', 'G', and 'T' 
# occur in s

def GetCount(string, n):
    count = 0
    for i in string:
        if i == n:
            count += 1
        
    return count
 

DNA = "AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC"
A = GetCount(DNA, 'A')
C = GetCount(DNA, 'C')
G = GetCount(DNA, 'G')
T = GetCount(DNA, 'T')

print(str(A) + str(C) + str(G) + str(T))