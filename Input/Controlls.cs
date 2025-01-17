// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controlls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controlls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controlls"",
    ""maps"": [
        {
            ""name"": ""TrackCreating"",
            ""id"": ""0b7cb0e2-95ab-43ad-a8fe-6b69ca1b0b9d"",
            ""actions"": [
                {
                    ""name"": ""PlaceNode"",
                    ""type"": ""Button"",
                    ""id"": ""39084e4d-dded-4eb1-9e09-c26d0223a663"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""8de4b36a-5510-4e9f-95fd-65f43a8b8445"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cursor"",
                    ""type"": ""Value"",
                    ""id"": ""db7bf927-9399-4a93-8ab9-8955cbfad303"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateLeft"",
                    ""type"": ""Button"",
                    ""id"": ""19db7538-316b-43f2-8e46-993b9b347e4f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateRight"",
                    ""type"": ""Button"",
                    ""id"": ""66daa3d6-e735-4b1d-9c33-cacbd3cf3844"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drag"",
                    ""type"": ""Button"",
                    ""id"": ""e2cdcfc6-be38-4c8e-9f24-cf896bb20094"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""09b3b74f-9394-40c0-9788-f7f120791afb"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Temp Reorder"",
                    ""type"": ""Button"",
                    ""id"": ""f10a77df-efd3-486d-905b-932cf0047252"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Delete"",
                    ""type"": ""Button"",
                    ""id"": ""b66f0f3f-c5f5-425b-a450-bb74b87e3b9c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToogleLoop"",
                    ""type"": ""Button"",
                    ""id"": ""6caa1acb-e4f1-4eab-bcc2-b64127d37b25"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Press"",
                    ""type"": ""Button"",
                    ""id"": ""20577c44-f911-4611-87ba-e1e665f1b952"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Value"",
                    ""id"": ""d0a8d0b2-c443-445a-be99-484ad05ecea9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""e84484e0-90e8-4e76-ac10-62655c7c2ed6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1116ed16-aba5-44ac-af9d-ea851bf6a4d6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PlaceNode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ccd0ff0d-4536-4914-ae40-a20e02e337f3"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""PlaceNode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""8138f098-eb75-4b38-beca-d7c239d830c9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d75d66be-926c-4431-a099-205d072bbbe6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9e2eaf53-2063-443b-8f7b-03cf6b9c021b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""23e4e9ae-5469-4e59-a4f5-e5bb5f61c7aa"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2190d9c9-3305-4f2d-9e8a-0cb2d5534260"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c3c12ee8-f833-4e7f-9bb4-491e50eb9702"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4847f10d-c838-403a-ba42-562e539f62e1"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6e8879f-1e85-42c2-98cc-fa65b35e9135"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8e82c9f-e39c-47a2-a64b-93773b8660cc"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""710c5455-d9c7-4866-ba42-8d8fb4c255da"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""RotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c981ec43-c510-4c87-a2c9-b900cc24cbf0"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4558e957-dba4-4fec-9ee1-0d71df9a568b"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""RotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdbb4bf2-a2c0-4729-a1e4-59543b35a8be"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3145fdf5-ceca-46d9-96c7-b6022c15099b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""b68d3b0b-ef68-4cc7-8392-9d3e0648a07d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1026eb88-3386-42ac-9be8-8c0e7324eea6"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2cda1611-d9a7-46ad-9504-490e1a03a400"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Controller"",
                    ""id"": ""ac05f53d-96a9-4d3b-87d9-f7c4aa9a1e4b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c3485df8-8ee2-48d4-b157-a605e9fb2e0c"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2c840adb-336f-42fc-9c83-d2d5d3850cc8"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""438cfa5a-7b11-4301-a5c4-66464a7133c5"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Temp Reorder"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""750d37c2-9874-43b1-8926-ab78e81daad1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Temp Reorder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d481d2fc-e231-438d-94e6-4b8bcaa698d2"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Temp Reorder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6687b5cc-3e1a-42b4-a222-709a9ff4416a"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Delete"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""deead9f6-b69a-44d5-bb4d-d7a187dcc8cd"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""Delete"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9903b867-3fa1-41f3-8c7e-2fba99b80194"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ToogleLoop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bcf9125c-16fc-40e3-93a5-9a97cae9e258"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""ToogleLoop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d06208b-1a6e-4a4a-b74c-acb4cd749f30"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38a82a39-95bb-476f-a734-d3ca2699cd44"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01e4475a-fcd3-4290-bfe9-0fd2118a6562"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""963f877a-e838-4f5e-8641-bc1434ddc897"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""43efb292-3cc9-4a72-91eb-07c8493e9101"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CarController"",
            ""id"": ""86616802-5f94-40b9-8cb0-934a6cb9bae3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e98a8402-7c4c-4384-b129-26ea8c7f2c90"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""590c370c-cb2d-4948-ab95-038367d13f05"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drift"",
                    ""type"": ""Button"",
                    ""id"": ""7c6531c0-720c-40f2-9ba5-cbae07914b2e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reverse"",
                    ""type"": ""Button"",
                    ""id"": ""aca8793a-a721-47b8-ac2b-7068edbdc220"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""2ffd6fad-e481-497f-ab62-ba1a02166724"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""30ecdaba-9591-4f4b-acb7-7574208ed4a8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69958ebe-2753-4b16-a670-ce2b8bea6699"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b37bd493-a313-4244-8ea8-6136a4f76c01"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""6615032c-9f0e-4785-979f-3da74e216e6f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0d0fac44-2f86-4d1b-b1bb-0707eae33bfb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""41abc078-4f9d-46d6-995d-4905df5b4322"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7c853c51-6ce7-4acb-907b-ff3d29d0b586"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""Drift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af78da53-17f1-429e-bd33-9e3827214e31"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f58df786-54f3-4d44-b32c-a8e01b719678"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""Reverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c32e939d-9d83-483e-a7f9-2814378b0dd5"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7fc4f23c-8e64-4862-92d9-849969487ce4"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MainMenu"",
            ""id"": ""0b3f6e61-a10d-4b1a-bf22-61484703e6ae"",
            ""actions"": [
                {
                    ""name"": ""TabLeft"",
                    ""type"": ""Button"",
                    ""id"": ""da54d3fa-ea22-4981-83bb-c5642b05d6d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TabRight"",
                    ""type"": ""Button"",
                    ""id"": ""feb2a151-63da-473a-9b73-944883e14dc0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""b078b151-c196-4703-aa3f-01a8e90f83a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1b4d155a-a125-46b0-9cf6-cde8b9600107"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""TabLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3eded7b4-68e0-46cf-8d0e-7548d2defb58"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""TabLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""819ceca2-be63-4cdb-88df-6dc5d960bc13"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""TabRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb87d76a-032b-445e-8bbd-00f5b49fde8e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""TabRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc77ad15-8c54-40f2-a874-9508724279de"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbcbc119-ee8c-4805-a07f-850e0590f063"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""JoyPad"",
            ""bindingGroup"": ""JoyPad"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // TrackCreating
        m_TrackCreating = asset.FindActionMap("TrackCreating", throwIfNotFound: true);
        m_TrackCreating_PlaceNode = m_TrackCreating.FindAction("PlaceNode", throwIfNotFound: true);
        m_TrackCreating_Move = m_TrackCreating.FindAction("Move", throwIfNotFound: true);
        m_TrackCreating_Cursor = m_TrackCreating.FindAction("Cursor", throwIfNotFound: true);
        m_TrackCreating_RotateLeft = m_TrackCreating.FindAction("RotateLeft", throwIfNotFound: true);
        m_TrackCreating_RotateRight = m_TrackCreating.FindAction("RotateRight", throwIfNotFound: true);
        m_TrackCreating_Drag = m_TrackCreating.FindAction("Drag", throwIfNotFound: true);
        m_TrackCreating_Zoom = m_TrackCreating.FindAction("Zoom", throwIfNotFound: true);
        m_TrackCreating_TempReorder = m_TrackCreating.FindAction("Temp Reorder", throwIfNotFound: true);
        m_TrackCreating_Delete = m_TrackCreating.FindAction("Delete", throwIfNotFound: true);
        m_TrackCreating_ToogleLoop = m_TrackCreating.FindAction("ToogleLoop", throwIfNotFound: true);
        m_TrackCreating_Press = m_TrackCreating.FindAction("Press", throwIfNotFound: true);
        m_TrackCreating_Mouse = m_TrackCreating.FindAction("Mouse", throwIfNotFound: true);
        m_TrackCreating_Start = m_TrackCreating.FindAction("Start", throwIfNotFound: true);
        // CarController
        m_CarController = asset.FindActionMap("CarController", throwIfNotFound: true);
        m_CarController_Move = m_CarController.FindAction("Move", throwIfNotFound: true);
        m_CarController_Accelerate = m_CarController.FindAction("Accelerate", throwIfNotFound: true);
        m_CarController_Drift = m_CarController.FindAction("Drift", throwIfNotFound: true);
        m_CarController_Reverse = m_CarController.FindAction("Reverse", throwIfNotFound: true);
        m_CarController_Menu = m_CarController.FindAction("Menu", throwIfNotFound: true);
        // MainMenu
        m_MainMenu = asset.FindActionMap("MainMenu", throwIfNotFound: true);
        m_MainMenu_TabLeft = m_MainMenu.FindAction("TabLeft", throwIfNotFound: true);
        m_MainMenu_TabRight = m_MainMenu.FindAction("TabRight", throwIfNotFound: true);
        m_MainMenu_Back = m_MainMenu.FindAction("Back", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // TrackCreating
    private readonly InputActionMap m_TrackCreating;
    private ITrackCreatingActions m_TrackCreatingActionsCallbackInterface;
    private readonly InputAction m_TrackCreating_PlaceNode;
    private readonly InputAction m_TrackCreating_Move;
    private readonly InputAction m_TrackCreating_Cursor;
    private readonly InputAction m_TrackCreating_RotateLeft;
    private readonly InputAction m_TrackCreating_RotateRight;
    private readonly InputAction m_TrackCreating_Drag;
    private readonly InputAction m_TrackCreating_Zoom;
    private readonly InputAction m_TrackCreating_TempReorder;
    private readonly InputAction m_TrackCreating_Delete;
    private readonly InputAction m_TrackCreating_ToogleLoop;
    private readonly InputAction m_TrackCreating_Press;
    private readonly InputAction m_TrackCreating_Mouse;
    private readonly InputAction m_TrackCreating_Start;
    public struct TrackCreatingActions
    {
        private @Controlls m_Wrapper;
        public TrackCreatingActions(@Controlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlaceNode => m_Wrapper.m_TrackCreating_PlaceNode;
        public InputAction @Move => m_Wrapper.m_TrackCreating_Move;
        public InputAction @Cursor => m_Wrapper.m_TrackCreating_Cursor;
        public InputAction @RotateLeft => m_Wrapper.m_TrackCreating_RotateLeft;
        public InputAction @RotateRight => m_Wrapper.m_TrackCreating_RotateRight;
        public InputAction @Drag => m_Wrapper.m_TrackCreating_Drag;
        public InputAction @Zoom => m_Wrapper.m_TrackCreating_Zoom;
        public InputAction @TempReorder => m_Wrapper.m_TrackCreating_TempReorder;
        public InputAction @Delete => m_Wrapper.m_TrackCreating_Delete;
        public InputAction @ToogleLoop => m_Wrapper.m_TrackCreating_ToogleLoop;
        public InputAction @Press => m_Wrapper.m_TrackCreating_Press;
        public InputAction @Mouse => m_Wrapper.m_TrackCreating_Mouse;
        public InputAction @Start => m_Wrapper.m_TrackCreating_Start;
        public InputActionMap Get() { return m_Wrapper.m_TrackCreating; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TrackCreatingActions set) { return set.Get(); }
        public void SetCallbacks(ITrackCreatingActions instance)
        {
            if (m_Wrapper.m_TrackCreatingActionsCallbackInterface != null)
            {
                @PlaceNode.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnPlaceNode;
                @PlaceNode.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnPlaceNode;
                @PlaceNode.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnPlaceNode;
                @Move.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnMove;
                @Cursor.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnCursor;
                @Cursor.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnCursor;
                @Cursor.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnCursor;
                @RotateLeft.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnRotateLeft;
                @RotateLeft.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnRotateLeft;
                @RotateLeft.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnRotateLeft;
                @RotateRight.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnRotateRight;
                @RotateRight.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnRotateRight;
                @RotateRight.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnRotateRight;
                @Drag.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnDrag;
                @Drag.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnDrag;
                @Drag.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnDrag;
                @Zoom.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnZoom;
                @TempReorder.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnTempReorder;
                @TempReorder.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnTempReorder;
                @TempReorder.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnTempReorder;
                @Delete.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnDelete;
                @Delete.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnDelete;
                @Delete.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnDelete;
                @ToogleLoop.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnToogleLoop;
                @ToogleLoop.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnToogleLoop;
                @ToogleLoop.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnToogleLoop;
                @Press.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnPress;
                @Press.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnPress;
                @Press.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnPress;
                @Mouse.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnMouse;
                @Mouse.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnMouse;
                @Mouse.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnMouse;
                @Start.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnStart;
            }
            m_Wrapper.m_TrackCreatingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PlaceNode.started += instance.OnPlaceNode;
                @PlaceNode.performed += instance.OnPlaceNode;
                @PlaceNode.canceled += instance.OnPlaceNode;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Cursor.started += instance.OnCursor;
                @Cursor.performed += instance.OnCursor;
                @Cursor.canceled += instance.OnCursor;
                @RotateLeft.started += instance.OnRotateLeft;
                @RotateLeft.performed += instance.OnRotateLeft;
                @RotateLeft.canceled += instance.OnRotateLeft;
                @RotateRight.started += instance.OnRotateRight;
                @RotateRight.performed += instance.OnRotateRight;
                @RotateRight.canceled += instance.OnRotateRight;
                @Drag.started += instance.OnDrag;
                @Drag.performed += instance.OnDrag;
                @Drag.canceled += instance.OnDrag;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @TempReorder.started += instance.OnTempReorder;
                @TempReorder.performed += instance.OnTempReorder;
                @TempReorder.canceled += instance.OnTempReorder;
                @Delete.started += instance.OnDelete;
                @Delete.performed += instance.OnDelete;
                @Delete.canceled += instance.OnDelete;
                @ToogleLoop.started += instance.OnToogleLoop;
                @ToogleLoop.performed += instance.OnToogleLoop;
                @ToogleLoop.canceled += instance.OnToogleLoop;
                @Press.started += instance.OnPress;
                @Press.performed += instance.OnPress;
                @Press.canceled += instance.OnPress;
                @Mouse.started += instance.OnMouse;
                @Mouse.performed += instance.OnMouse;
                @Mouse.canceled += instance.OnMouse;
                @Start.started += instance.OnStart;
                @Start.performed += instance.OnStart;
                @Start.canceled += instance.OnStart;
            }
        }
    }
    public TrackCreatingActions @TrackCreating => new TrackCreatingActions(this);

    // CarController
    private readonly InputActionMap m_CarController;
    private ICarControllerActions m_CarControllerActionsCallbackInterface;
    private readonly InputAction m_CarController_Move;
    private readonly InputAction m_CarController_Accelerate;
    private readonly InputAction m_CarController_Drift;
    private readonly InputAction m_CarController_Reverse;
    private readonly InputAction m_CarController_Menu;
    public struct CarControllerActions
    {
        private @Controlls m_Wrapper;
        public CarControllerActions(@Controlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_CarController_Move;
        public InputAction @Accelerate => m_Wrapper.m_CarController_Accelerate;
        public InputAction @Drift => m_Wrapper.m_CarController_Drift;
        public InputAction @Reverse => m_Wrapper.m_CarController_Reverse;
        public InputAction @Menu => m_Wrapper.m_CarController_Menu;
        public InputActionMap Get() { return m_Wrapper.m_CarController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CarControllerActions set) { return set.Get(); }
        public void SetCallbacks(ICarControllerActions instance)
        {
            if (m_Wrapper.m_CarControllerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnMove;
                @Accelerate.started -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnAccelerate;
                @Accelerate.performed -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnAccelerate;
                @Accelerate.canceled -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnAccelerate;
                @Drift.started -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnDrift;
                @Drift.performed -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnDrift;
                @Drift.canceled -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnDrift;
                @Reverse.started -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnReverse;
                @Reverse.performed -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnReverse;
                @Reverse.canceled -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnReverse;
                @Menu.started -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_CarControllerActionsCallbackInterface.OnMenu;
            }
            m_Wrapper.m_CarControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Accelerate.started += instance.OnAccelerate;
                @Accelerate.performed += instance.OnAccelerate;
                @Accelerate.canceled += instance.OnAccelerate;
                @Drift.started += instance.OnDrift;
                @Drift.performed += instance.OnDrift;
                @Drift.canceled += instance.OnDrift;
                @Reverse.started += instance.OnReverse;
                @Reverse.performed += instance.OnReverse;
                @Reverse.canceled += instance.OnReverse;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
            }
        }
    }
    public CarControllerActions @CarController => new CarControllerActions(this);

    // MainMenu
    private readonly InputActionMap m_MainMenu;
    private IMainMenuActions m_MainMenuActionsCallbackInterface;
    private readonly InputAction m_MainMenu_TabLeft;
    private readonly InputAction m_MainMenu_TabRight;
    private readonly InputAction m_MainMenu_Back;
    public struct MainMenuActions
    {
        private @Controlls m_Wrapper;
        public MainMenuActions(@Controlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @TabLeft => m_Wrapper.m_MainMenu_TabLeft;
        public InputAction @TabRight => m_Wrapper.m_MainMenu_TabRight;
        public InputAction @Back => m_Wrapper.m_MainMenu_Back;
        public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
        public void SetCallbacks(IMainMenuActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsCallbackInterface != null)
            {
                @TabLeft.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnTabLeft;
                @TabLeft.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnTabLeft;
                @TabLeft.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnTabLeft;
                @TabRight.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnTabRight;
                @TabRight.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnTabRight;
                @TabRight.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnTabRight;
                @Back.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_MainMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TabLeft.started += instance.OnTabLeft;
                @TabLeft.performed += instance.OnTabLeft;
                @TabLeft.canceled += instance.OnTabLeft;
                @TabRight.started += instance.OnTabRight;
                @TabRight.performed += instance.OnTabRight;
                @TabRight.canceled += instance.OnTabRight;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public MainMenuActions @MainMenu => new MainMenuActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_JoyPadSchemeIndex = -1;
    public InputControlScheme JoyPadScheme
    {
        get
        {
            if (m_JoyPadSchemeIndex == -1) m_JoyPadSchemeIndex = asset.FindControlSchemeIndex("JoyPad");
            return asset.controlSchemes[m_JoyPadSchemeIndex];
        }
    }
    public interface ITrackCreatingActions
    {
        void OnPlaceNode(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnCursor(InputAction.CallbackContext context);
        void OnRotateLeft(InputAction.CallbackContext context);
        void OnRotateRight(InputAction.CallbackContext context);
        void OnDrag(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
        void OnTempReorder(InputAction.CallbackContext context);
        void OnDelete(InputAction.CallbackContext context);
        void OnToogleLoop(InputAction.CallbackContext context);
        void OnPress(InputAction.CallbackContext context);
        void OnMouse(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
    }
    public interface ICarControllerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAccelerate(InputAction.CallbackContext context);
        void OnDrift(InputAction.CallbackContext context);
        void OnReverse(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
    }
    public interface IMainMenuActions
    {
        void OnTabLeft(InputAction.CallbackContext context);
        void OnTabRight(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
}
