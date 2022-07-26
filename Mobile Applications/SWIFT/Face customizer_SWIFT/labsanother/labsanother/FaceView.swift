//
//  FaceView.swift
//
//  Created by Lab PUM on 30.09.2018.
//  Copyright © 2018 MM. All rights reserved.
//

import UIKit

class FaceView: UIView {

    var red: CGFloat = 0.12
    var green: CGFloat = 0.64
    var blue: CGFloat = 1.0
    var happyness: Float = 0.5    // Only override drawRect: if you perform custom drawing.
    // An empty implementation adversely affects performance during animation.
    override func draw(_ rect: CGRect) {
        // Drawing code
        let bounds:CGRect = self.bounds
        
       
        //wyznaczanie srodka widoku
        var midPoint=CGPoint() // center of our bounds in our coordinate system
        midPoint.x = bounds.origin.x + bounds.size.width/2
        midPoint.y = bounds.origin.y + bounds.size.height/2
        
        //rysowanko kół
        let path:UIBezierPath=UIBezierPath()
        path.addArc(withCenter: midPoint, radius: 110, startAngle: 0, endAngle: CGFloat(2 * Double.pi), clockwise: true)
        path.lineWidth=5
        let color = UIColor(red:self.red, green:self.green, blue:self.blue, alpha: alpha)
        color.setFill()
        path.stroke()
        path.fill()

        //rysowanko
        var oko1 = CGPoint()
        oko1.x = midPoint.x - 45
        oko1.y = midPoint.y - 50
        
        let oko1Path:UIBezierPath=UIBezierPath()
        oko1Path.addArc(withCenter: oko1, radius: 10, startAngle: 0, endAngle: CGFloat(2 * Double.pi), clockwise: true)
        UIColor.white.setFill()
        oko1Path.lineWidth=5
        oko1Path.stroke()
        oko1Path.fill()
        
        var oko2 = CGPoint()
        oko2.x = midPoint.x + 45
        oko2.y = midPoint.y - 50
        //rysowanko
        let oko2Path:UIBezierPath=UIBezierPath()
        oko2Path.addArc(withCenter: oko2, radius: 10, startAngle: 0, endAngle: CGFloat(2 * Double.pi), clockwise: true)
        UIColor.white.setFill()
        oko2Path.lineWidth=5
        oko2Path.stroke()
        oko2Path.fill()
        
        
        var smilePointLeft = CGPoint()
        smilePointLeft.x = midPoint.x - 45
        smilePointLeft.y = midPoint.y + 30
        
        var smilePointRight = CGPoint()
        smilePointRight.x = midPoint.x + 45
        smilePointRight.y = midPoint.y + 30
        
        var smileControlPoint = CGPoint()
        smileControlPoint.x = midPoint.x
        smileControlPoint.y = midPoint.y + CGFloat((65 * happyness))
        
        let smilePath:UIBezierPath = UIBezierPath()
        
        smilePath.move(to:smilePointLeft)
        smilePath.addQuadCurve(to: smilePointRight, controlPoint: smileControlPoint)
        smilePath.lineWidth = 5
        smilePath.stroke()
    }
    

}
