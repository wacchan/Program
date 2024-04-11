public class b_zenkasiki
    function Main as integer
        dim inputCount
        inputCount=console.readline()
        dim fibo(40) as Integer
        fibo(0) = 1
        fibo(1) = 1
        for i = 3 to 40
            fibo(i)=fibo(i-1)+fibo(i-2)
        next
        dim inputNums(inputCount-1) as Integer 
        for i = 0 to inputCount - 1
            console.WriteLine fibo(console.readline())
        Next 

        ' Console.WriteLine (a)
        return 0
    End function
end class