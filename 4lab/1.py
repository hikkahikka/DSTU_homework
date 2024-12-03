from random import *


def IsPalindrom (k):
    a = 0
    for  i in range(len(str(k))-1, 0-1, -1):
        a*=10
        a+=int(str(k)[i])
    return a==k


mass=[]
for i in range(10):
    mass.append(randint(0,100000))
    print(mass[i], IsPalindrom(mass[i]))

    

