import math
import os
from unittest import result

class MyBigNumber:
    a = "0"
    b = "0"
    chuoia = []
    chuoib = []
    result = ""
    def __init__(self, a, b):
        self.a = a
        self.b = b

    def sum(self):
        self.chuoia = list(self.a)
        self.chuoib = list(self.b)

        
        if(len(self.chuoia)>len(self.chuoib)):
            chenhlech = len(self.chuoia) - len(self.chuoib)
            for i in range(0,chenhlech):
                self.chuoib.insert(0,0)
        else:
            chenhlech = len(self.chuoib) - len(self.chuoia)
            for i in range(0,chenhlech):
                self.chuoia.insert(0,0)
        
        dodaichuoi = len(self.chuoia)

        tmpresult = []
        rem = 0
        buoc = 0
        
        while(dodaichuoi!=0):
            buoc += 1
            if rem ==0 :
                tmpsum = int(self.chuoia[dodaichuoi-1]) + int(self.chuoib[dodaichuoi-1])
            else:
                tmpsum = int(self.chuoia[dodaichuoi-1]) + int(self.chuoib[dodaichuoi-1]) + rem
            

            if tmpsum>=10:
                rem = 1
                tmpresult.insert(0,tmpsum-10)
                print(f"Bước {buoc}: {self.chuoia[dodaichuoi-1]} + {self.chuoib[dodaichuoi-1]} = {tmpsum} thêm {tmpsum-1} nhớ 1")
                if(dodaichuoi-1==0):
                    tmpresult.insert(0,1)
                    print(f"Bước {buoc+1}: Thêm 1. Hết")
            else:
                rem = 0
                tmpresult.insert(0,tmpsum)
                print(f"Bước {buoc}: {self.chuoia[dodaichuoi-1]} + {self.chuoib[dodaichuoi-1]} = {tmpsum} thêm {tmpsum}")

            dodaichuoi = dodaichuoi - 1

        for i in tmpresult:
            self.result += str(i)
        print(f"Ket qua cho phep tinh la {self.result}")

def main():
    exit = ""
    while(exit!="x"):
        os.system('cls')
        print("Nhap a va b:")
        f = input(" a = ")
        s = input(" b = ")
        cal = MyBigNumber(f, s)
        cal.sum()
        exit = input("Input 'x' to exit program")
main()