'Jessica McArthur
'RCET0265
'Spring 2020
'Shuffle the Deck
'https://github.com/jmcarth4/ 

Option Explicit On
Option Strict On
Option Compare Text

Module ShuffleTheDeck

    'Shuffles the cards
    Sub Main()
        ' Creates array of cards
        Dim givenCard(3, 12) As Boolean
        Dim symbol As Integer
        Dim value As Integer
        Dim count As Integer
        Dim userInput As String

        'Cards are drawn, with no repeats until the array is full or cleared
        Do
            'generates a random card to be drawn.
            Do
                symbol = RandomNumberInRange(3)
                value = RandomNumberInRange(12)
            Loop While givenCard(symbol, value)

            'Count how many times random draw had a successful card. (not a repeat)
            count += 1
            givenCard(symbol, value) = True

            'Dealt cards are displayed in the display function
            Console.Clear()
            Diagram(givenCard)

            'prompts user to  deal, shuffle or exit the program
            Console.WriteLine()
            Console.WriteLine()
            Console.WriteLine("Press Enter to deal a card.")
            Console.WriteLine("Press C and Enter to shuffle the deck.")
            Console.WriteLine(" Press Q and Enter to quit.")

            'the array is cleared when prompted or becomes full
            userInput = Console.ReadLine()
            If userInput = "c" Or count >= 52 Then
                ResetDisplay(givenCard)
                count = 0
            End If

            'Loops until user exits the program
        Loop While userInput <> "Q"
    End Sub

    ' displays the cards dealt in neat labeled table
    Sub Diagram(ByRef givenCard(,) As Boolean)
        Dim suite() As String = {"  |", " H|", " C|", " D|", " S"}
        Dim temp As String

        'header - display suites
        For column = 0 To UBound(suite)
            Console.Write(suite(column))
        Next
        Console.WriteLine()

        ' column - display card vaule
        For row = 0 To 12
            Select Case row
                Case 0
                    temp = " A"
                Case 1 To 9
                    temp = CStr(row + 1).PadLeft(2)
                Case 10
                    temp = " J"
                Case 11
                    temp = " Q"
                Case 12
                    temp = " K"
            End Select
            Console.Write(temp)

            ' fill array with drawn cards
            For column = 0 To 3

                If givenCard(column, row) = True Then
                    temp = "| x"
                Else
                    temp = "|  "

                End If
                Console.Write(temp)
            Next
            Console.WriteLine()
        Next
    End Sub

    'Clears the array (shuffles the cards) when prompted or array is full.
    Sub ResetDisplay(ByRef givenCard(,) As Boolean)
        ReDim givenCard(3, 12)
    End Sub

    'Function to generate random number
    Function RandomNumberInRange(Optional max% = 10%, Optional min% = 0%) As Integer
        Dim _max% = max - min
        If _max < 0 Then
            Throw New System.ArgumentException("Maximum number must be greater than minimum number")
        End If
        Randomize(DateTime.Now.Millisecond)
        Return CInt(System.Math.Floor(Rnd() * (_max + 1))) + min
    End Function
End Module
