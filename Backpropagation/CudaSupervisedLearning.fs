﻿namespace Backpropagation

module CudaSupervisedLearning =

    open System
    open Alea.CUDA
    open Alea.CUDA.Utilities
    open Common.NeuralNet
    open CudaTemplates
    open Parameters

    type BackPropagationNetwork with
        member network.TrainGpu (rnd : Random) (trainingSet : TrainingSet) =
            use runTrainNeuralNetEpochProgram = 32 |> runTrainNeuralNetEpochTemplate |> Compiler.load Worker.Default
            runTrainNeuralNetEpochProgram.Run network trainingSet rnd
        member network.ReadTestSetGpu (testSet : TestSet) =
            use runReadNeuralNetTemplate = 32 |> runReadNeuralNetTemplate |> Compiler.load Worker.Default
            runReadNeuralNetTemplate.Run network testSet
