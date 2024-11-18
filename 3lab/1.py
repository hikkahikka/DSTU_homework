from random import *
while 1:
    try:
        m = int(input('Input M: '))
        n = int(input('Input N: '))
        if m<=0 or n<=0:
            print('Value M and N must be more than 0!!!')
        else:
            break
    except ValueError:
        print('Invalid data type!!!')

mass = [[0]*m for i in range (n)]


for i in range(n):
    for j in range(m):
        mass[i][j]= randint(1,9)

for i in range(n):
    for j in range(m):
        print(mass[i][j], end = ' ')
    print()
    
print('_'*20)

for i in range(n):
    if i%2==0:
        for j in range(0, m, 1):
            print(mass[i][j], end = ' ')
    else:
        for j in range(m-1,0-1, -1):
            print(mass[i][j], end = ' ')
    
    print()
