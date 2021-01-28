//
//  FirstViewController.swift
//  LABS3
//
//  Created by Student on 22/01/2021.
//  Copyright © 2021 Klaudia Janecka. All rights reserved.
//

import UIKit


class FirstViewController: UIViewController {

  
    @IBOutlet var viewGesture: UIView!
    var pinchGesture  = UIPinchGestureRecognizer()
    
    override func viewDidLoad() {
        super.viewDidLoad()
        pinchGesture = UIPinchGestureRecognizer(target: self, action: #selector(handlePinch(_:)))
        viewGesture.isUserInteractionEnabled = true
        viewGesture.addGestureRecognizer(pinchGesture)        // Do any additional setup after loading the view.
    }
    
    func gestureRecognizer(_ gestureRecognizer: UIGestureRecognizer,
                           shouldRecognizeSimultaneouslyWith otherGestureRecognizer: UIGestureRecognizer)
        -> Bool {
    return true
    
    }
    
    @IBAction func handleRotate(_ sender: UIRotationGestureRecognizer) {
    
        
        //sender.rotation - kąt o który obracamy obiekt
        sender.view!.transform = sender.view!.transform.rotated(by: sender.rotation)
        
        //gest ciagly nalezy wyzrowac bo jak nie to przyrost rotacji jest geometryczny i bedzie obracac sie coraz szybciej
        sender.rotation = 0
    }
    
    @IBAction func handlePan(_ sender: UIPanGestureRecognizer) {
        
        let translation = sender.translation(in: self.view)
        
        if let view =  sender.view {
            view.center = CGPoint( x:view.center.x + translation.x,
                                   y:view.center.y + translation.y)}
        sender.setTranslation(CGPoint.zero, in: self.view)
        }
    
    @IBAction func handlePinch(_ sender: UIPinchGestureRecognizer) {
        self.view.bringSubviewToFront(viewGesture)
        sender.view?.transform = (sender.view?.transform)!.scaledBy(x: sender.scale, y: sender.scale)
        
        sender.scale = 1.0
        
    }
}

