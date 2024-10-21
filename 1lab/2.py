from math import *
while 1:
    try:
        e = abs(float(input('Input e: ')))
        if e!=0:
            break
        else:
            print("E must be more than 0!!!")
    except ValueError:
        print('Invalid data type!!!')

summ= 0


for i in range (1, int(sqrt(1/e)+1)):
    summ+=1/i**2



##n = 1   ##second way
##while 1:
##    if 1/n**2>=e:
##        summ+=1/n**2
##        n+=1
##    else:
##        break


    
print(summ)
