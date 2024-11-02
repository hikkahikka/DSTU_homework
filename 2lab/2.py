s = input("Input text: ")##.split()

sl = ''
ss=[]
for i in s:    
    if i!=" ":
        sl +=i
    else:
        if sl!='':
            ss.append(sl)
        sl = ''
if sl!='':
            ss.append(sl)        


vowels_eng="eyuioa"
vowels_rus="уеыаоэяиюё"
counter = 0
for i in ss:
    if ((i[0] in vowels_eng) or (i[0] in vowels_rus)):
        counter +=1
        print(i)
print(counter)
