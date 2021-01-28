//
//  ViewController2.swift
//  labsanother
//
//  Created by Student on 21/01/2021.
//  Copyright © 2021 Klaudia Janecka. All rights reserved.
//

import UIKit

class ViewController2: UIViewController {

    @IBOutlet weak var greenSlider: UISlider!
    @IBOutlet weak var blueSlider: UISlider!
    @IBOutlet weak var redSlider: UISlider!
    @IBOutlet weak var label2: UILabel!
    
    var redValue: Float = 0.5
    var greenValue: Float = 0.5
    var blueValue: Float = 0.5
    
   
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        redSlider.value = redValue
        greenSlider.value = greenValue
        blueSlider.value = blueValue
        // Do any additional setup after loading the view.
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
