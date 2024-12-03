def Palindrom(s, a):
    if a==len(s):
        return True
    if s[a]!=s[len(s)-1-a]:
        return False
    
    return Palindrom(s, a+1)


for i in range(5):
    s = input('Input string: ')
    print(Palindrom(s,0))
