from random import *
while 1:
    try:
        n = int(input('Input : '))
        
        if n==0:
            print('n must be more than 0 ')
        else:
            break
    except ValueError:
        print('Invalid data type!!!')


mass = []
for i in range(n):
    mass.append(randint(-15,15))
print("List:", *mass)


proiz = 1
pos = 0
for i in mass:
    if i>0:
        proiz*=i
        pos+=1
    

if pos ==0:
    proiz = "there are no positive elements"
print ("Composition:",proiz)

mini = mass[0]
for i in mass:
    if i<mini:
        mini = i
        
summ=0
for i in mass:
    if i!=mini:
        summ+=abs(i)
    else:
        break
print("Amount:", summ)
