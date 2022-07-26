//
//  SecondViewController.swift
//  LABS3
//
//  Created by Student on 22/01/2021.
//  Copyright © 2021 Klaudia Janecka. All rights reserved.
//

import UIKit

class SecondViewController: UIViewController {


    @IBOutlet var secondView: UIView!
    var tap = UITapGestureRecognizer()
    var doubleTap = UITapGestureRecognizer()
    var swipeRight = UISwipeGestureRecognizer()
    var timer :Timer?
    var time : Int = 0
    
    @IBOutlet weak var counterLabel: UILabel!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        secondView.gestureRecognizers?.removeAll()
        
        swipeRight = UISwipeGestureRecognizer(target: self, action: #selector(handleSwipe(_:)))
        swipeRight.direction = UISwipeGestureRecognizer.Direction.right
        secondView.addGestureRecognizer(swipeRight)
        
        tap = UITapGestureRecognizer(target: self, action: #selector(handleTap(_:)))
        tap.numberOfTouchesRequired=1
        secondView.addGestureRecognizer(tap)
        
        doubleTap = UITapGestureRecognizer(target: self, action: #selector(handleDoubleTap(_:)))
        doubleTap.numberOfTouchesRequired=2
        secondView.addGestureRecognizer(doubleTap)
        
        secondView.isUserInteractionEnabled = true
        
       
        
    }
    
    @objc func timer_start()
    {
    
        counterLabel.text =  String(time)
        time += 1;
        
    }
    func timer_stop()
    {
        
    }
    
    @objc func handleTap(_ sender: UITapGestureRecognizer? = nil)
    {
        if(timer == nil)
        {
       timer = Timer.scheduledTimer(timeInterval: 1,target: self, selector: #selector(timer_start), userInfo: nil, repeats: true)
        }
        
        timer_start()
    }



@objc func handleDoubleTap(_ sender: UITapGestureRecognizer? = nil)
{    
        timer?.invalidate()
        timer = nil
}
    
    @objc func handleSwipe(_ sender: UISwipeGestureRecognizer? = nil)
    {
        time = 0
        counterLabel.text = String(time)
        
    }
}


