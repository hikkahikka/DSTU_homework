while 1:
    try:
        a = int(input('Input first value: '))
        b = int(input('Input second value: '))
        if a>=b:
            print('Value A a must be less than value B!!!')
        else:
            break
    except ValueError:
        print('Invalid data type!!!')
    
        
for i in range(b-1, a, -1):
    print(i)

print("Count =",b-a-1) 
