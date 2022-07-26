//
//  ViewController3.swift
//  labsanother
//
//  Created by Student on 21/01/2021.
//  Copyright © 2021 Klaudia Janecka. All rights reserved.
//

import UIKit

//przekazanie innej klasie ktorea pelni funkcje delegata informacje na którym nam zależy
// :class - implementowany tylko przez klase a nie inne typy
protocol myDalegateProtocol:class {
    func myDelegateFunc(happyness:Float)
    }


class ViewController3: UIViewController {

    
    @IBOutlet weak var slider: UISlider!
    @IBOutlet var exit: UIView!
    
    var sliderValue :Float = 0.7
    weak var delegate : myDalegateProtocol? //nil
    //nie jest zainitializowany
    
    override func viewDidLoad() {
        slider.value = sliderValue;
        super.viewDidLoad()
    }
    
    //powrót z wykorzystaniem protokołu czyli coś a'la interfejsu ( rozszerzenie klasy o pewnej funkcjonalnosci)
    @IBAction func exit(_ sender: Any) {
        
        delegate?.myDelegateFunc(happyness: slider.value)
        //deklaracja protokolu\
        //jesli jest nil to nie wywolujr
    }
    
    /*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        // Get the new view controller using segue.destination.
        // Pass the selected object to the new view controller.
    }
    */

}
