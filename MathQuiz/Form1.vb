Public Class Form1
    'Creates a random object to create random integers
    Private randomizer As New Random

    'these integer variables store the numbers for the addition problem
    Private addend1 As Integer
    Private addend2 As Integer

    'these integer variables store the numbers for the subtraction problem
    Private minuend As Integer
    Private subtrahend As Integer

    'these integer variables store the numbers for the multiplication problem
    Private multiplicand As Integer
    Private multiplier As Integer

    'these integer variables store the numbers for the division problem
    Private dividend As Integer
    Private divisor As Integer

    'this integer variable keeps track of the remaining time
    Private timeLeft As Integer


    '-----Summary------------
    'Start the quiz by filling in all of the problems and starting the timer.
    '-----End of Summary-----
    Public Sub StartTheQuiz()
        'Fill in the addition problem
        'Generate two random numbers to add
        'store the values in the variables addend1 and addend2

        addend1 = randomizer.Next(51)
        addend2 = randomizer.Next(51)

        'Converts the two randomly generated numbers into strings 
        'so that they can be displayed in the labels

        plusLeftLabel.Text = addend1.ToString()
        plusRightLabel.Text = addend2.ToString()

        'sum is the name of the NumbericUpDown control
        'This step makes sure that its value is zero before adding any values to it
        sum.Value = 0

        'fill in the subtraction problem
        minuend = randomizer.Next(1, 101)
        subtrahend = randomizer.Next(1, minuend)
        minusLeftLabel.Text = minuend.ToString()
        minusRightLabel.Text = subtrahend.ToString()
        difference.Value = 0

        'fill in the multiplication problem
        multiplicand = randomizer.Next(2, 11)
        multiplier = randomizer.Next(2, 11)
        timesLeftLabel.Text = multiplicand.ToString()
        timesRightLabel.Text = multiplier.ToString()
        product.Value = 0

        'fill in the division problem
        divisor = randomizer.Next(2, 11)
        Dim temporaryQuotient As Integer = randomizer.Next(2, 11)
        dividend = divisor * temporaryQuotient
        dividedLeftLabel.Text = dividend.ToString
        dividedRightLabel.Text = divisor.ToString
        quotient.Value = 0

        'Start the timer
        timeLeft = 15
        timeLabel.Text = "15 seconds"
        Timer1.Start()

    End Sub
    'Calls the StartTheQuiz() method and disables the Start button
    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        StartTheQuiz()
        startButton.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If CheckTheAnswer() Then
            'CheckTheAnswer() is true then the answer is right. Stops the timer and shows a msgbox
            Timer1.Stop()
            MessageBox.Show("You got all of the answers right!", "Congratulations!")
            startButton.Enabled = True
        ElseIf timeLeft > 0 Then
            'display the new time left by updating the Time Left label
            timeLeft -= 1
            timeLabel.Text = timeLeft & " seconds"
        Else
            'if the user has ran out of time, a messagebox appears
            Timer1.Stop()
            timeLabel.Text = "Time's up!"
            sum.Value = addend1 + addend2
            difference.Value = minuend - subtrahend
            product.Value = multiplicand * multiplier
            quotient.Value = dividend / divisor
            MessageBox.Show("You didn't finish in time.", "Sorry!")
            startButton.Enabled = True
        End If
    End Sub

    '---Summary---
    'Checks the answer to see if the user was correct
    '---End of Summary----

    Public Function CheckTheAnswer() As Boolean
        If addend1 + addend2 = sum.Value AndAlso
            minuend - subtrahend = difference.Value AndAlso
            multiplicand * multiplier = product.Value AndAlso
            dividend / divisor = quotient.Value Then
            Return True
        Else
            Return False
        End If

    End Function

    '---Summary---
    'Modify the behavior of the NumbericUpDown dontrol to make it
    'easier to enter numeric values for the quiz
    '---End of Summary----
    Private Sub answer_Enter(sender As Object, e As EventArgs) Handles sum.Enter, quotient.Enter, product.Enter, difference.Enter
        ' Select the whole answer in the NumericUpDown control. 
        Dim answerBox = TryCast(sender, NumericUpDown)

        If answerBox IsNot Nothing Then
            Dim lengthOfAnswer = answerBox.Value.ToString().Length
            answerBox.Select(0, lengthOfAnswer)
        End If
    End Sub
End Class
