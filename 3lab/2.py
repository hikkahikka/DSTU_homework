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

mass = [[0]*n for i in range (m)]

for i in range(m):
    for j in range(n):
        mass[i][j]= randint(1,9)
        print(mass[i][j], end = ' ')
    print()

print('_'*20)

for i in range(m):
    for j in range(0, n, 2):
        for k in range(m-1):
            for l in range(m-1-k):
                if (mass[l][j]>mass[l+1][j]):
                    mass[l][j], mass[l+1][j]=mass[l+1][j], mass[l][j]
for i in range(m):
    for j in range(n):
        print(mass[i][j], end = ' ')
    print()
