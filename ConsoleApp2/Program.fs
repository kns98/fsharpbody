open System.Drawing

let drawToPng (filename: string) (width: int) (height: int) =
    // Create a bitmap
    use bitmap = new Bitmap(width, height)
    use graphics = Graphics.FromImage(bitmap)

    // Set background color to white
    graphics.Clear(Color.White)

    // Define drawing parameters
    let x, y, r = 250.0f, 200.0f, 50.0f // Head center (x, y) and radius
    let tx, ty = 150.0f, 200.0f         // Torso width and height
    let neckBaseX, neckBaseY = x, y + r // Neck base position

    // Create pens
    use bluePen = new Pen(Color.Blue, 2.0f)
    use greenPen = new Pen(Color.Green, 2.0f)
    use redPen = new Pen(Color.Red, 2.0f)

    // Draw head
    graphics.DrawEllipse(bluePen, x - r, y - r, 2.0f * r, 2.0f * r)

    // Draw neck
    graphics.DrawLine(greenPen, neckBaseX, neckBaseY - r, neckBaseX, neckBaseY)

    // Draw torso
    let torsoTopLeftX = neckBaseX - tx / 2.0f
    let torsoTopLeftY = neckBaseY
    graphics.DrawRectangle(
        redPen,
        RectangleF(torsoTopLeftX, torsoTopLeftY, tx, ty)
    )

    // Save the bitmap to a file
    bitmap.Save(filename, Imaging.ImageFormat.Png)

// Generate a PNG
drawToPng "head_neck_torso.png" 500 700
