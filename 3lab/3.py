from random import *
while 1:
    try:
        a = int(input('Input A: '))
        if a<=0 :
            print('Value A must be more than 0!!!')
        else:
            break
    except ValueError:
        print('Invalid data type!!!')
mass1=[]
mass2=[]

while len(mass1)!=a:
    r = randint(1,10)
    if r not in mass1:
        mass1.append(r)
        
for i in range(a):
    mass2.append(randint(1,10))
print(mass1,",", mass2, end = "\n"+"_"*50+"\n")

dic = {}

for i in range(a):
    dic[mass1[i]]=mass2[i]
print(dic)
