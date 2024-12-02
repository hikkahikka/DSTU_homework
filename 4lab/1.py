def IsPalindrom (k):
    a = 0
    for  i in range(len(str(k))-1, 0-1, -1):
        a*=10
        a+=int(str(k)[i])
    return a==k
    

while 1:
    try:
        k = int(input('Input K: '))
        
        if k<=0:
            print('Value K a must be more than 0!!!')
        else:
            break
    except ValueError:
        print('Invalid data type!!!')
    
print(IsPalindrom(k))
