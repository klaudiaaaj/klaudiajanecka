//
//  ViewController.swift
//  labsanother
//
//  Created by Student on 21/01/2021.
//  Copyright © 2021 Klaudia Janecka. All rights reserved.
//

import UIKit

class ViewController: UIViewController, myDalegateProtocol{
    

    @IBOutlet weak var faceView: FaceView!
    
    @IBAction func exit ( _ segue:UIStoryboardSegue)
    {
        let source = segue.source as! ViewController2
        faceView.red = CGFloat(source.redSlider.value)
        faceView.green = CGFloat(source.greenSlider.value)
        faceView.blue = CGFloat(source.blueSlider.value)
        faceView.setNeedsDisplay()
        
    }
    
    func myDelegateFunc(happyness: Float) {
        faceView.happyness = happyness
        faceView.setNeedsDisplay()
        dismiss(animated: true, completion: nil)
    }
    
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        if segue.identifier == "id2" {
            //pobieranie referencji do obiektu do ktorej przechodze
            let destination = segue.destination as! ViewController2
            
            destination.redValue=Float(faceView.red)
            destination.greenValue=Float(faceView.green)
            destination.blueValue=Float(faceView.blue)
            
        }
        else if segue.identifier == "id3" {
            let destination = segue.destination as! ViewController3
            destination.sliderValue = faceView.happyness
            //referencje do samego siebie
                destination.delegate = self
            }
    }
    
    override func viewDidLoad() {
        faceView.setNeedsDisplay()
        super.viewDidLoad()
        // Do any additional setup after loading the view.
    }

}

