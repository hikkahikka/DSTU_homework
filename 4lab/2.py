from math import *

def f (u,t):
    if u>0:
        return u + sin(t)
    return u+t


while 1:
    try:
        a = int(input('Input first value: '))
        b = int(input('Input second value: '))
        break
    except ValueError:
        print('Invalid data type!!!')
    
print(f(sin(a),b)+f(cos(b), a)+f(sin(a)**2,a-1)+f(sin(a)**2, cos(b)))
