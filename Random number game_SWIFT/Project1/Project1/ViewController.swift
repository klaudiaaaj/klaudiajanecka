//
//  ViewController.swift
//  Project1
//
//  Created by Klaudia Janecka on 20.01.2021.
//  Copyright © 2021 pl.polsl. All rights reserved.
//

import UIKit

class ViewController: UIViewController {
    
    var points = 0
    var currentValue: Int = 0
    var roundPoints=0
    var round : Int = 0
    var random: Int = 0;
    var sliderValue: Int = 0

    
    @IBOutlet weak var randomLabel: UILabel!
    
    @IBOutlet weak var slider: UISlider!
    
    @IBOutlet weak var roundLabel: UILabel!
    @IBOutlet weak var buttonHit: UIButton!
    @IBOutlet weak var pointsPerRound: UILabel!
    @IBAction func onChangeSlider(_ sender: UISlider) {
        sliderValue=Int(sender.value)
        
    }
    
    @IBAction func onHitAction(_ sender: Any) {
        roundPoints=100-abs( sliderValue-random)
        points+=roundPoints;
        if(round<10)
        {
            _ = UIAlertController(
                title: "Points per round:",
            message: "Score: " + String(roundPoints),
            preferredStyle: .alert
        )
        }
        if(round==10){
            let alert = UIAlertController(
                title: "Game Over",
                message: "Total points from 10 rounds: " + String(points),
                preferredStyle: .alert
            )
            alert.addAction(UIAlertAction(
                title: "Play Again",
                style: .default,
                handler: { (action:UIAlertAction) in self.startNewGame()}
            ))
            self.present(alert, animated: true, completion: nil)
            return
            
        };
        startRound()
    }
    
    func startRound()
    {
        
        round += 1;
        random=generateRandomValue()
        randomLabel.text=String(random)
        roundLabel.text=String(round)
        pointsPerRound.text=String(points)
        
    }
    
    func startNewGame()
    {
        let alert = UIAlertController(
            title: " BE THE COSER TO RANDOM",
            message: "Welcome to the game! Click and start! ",
            preferredStyle: .alert
        );
        let action = UIAlertAction(title: "OK", style: .default, handler: nil);
        alert.addAction(action);
        present(alert, animated: true, completion: nil);
        round=0;        points=0
        points=0
        startRound()
    }
    @IBAction func newGame(_ sender: Any) {
        startNewGame()
    }
    
    func generateRandomValue() -> Int
    {
        return Int.random(in: 1...100)
        
    }
        override func viewDidLoad() {
           startNewGame()
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
    }


}

