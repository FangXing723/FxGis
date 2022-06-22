using Mapsui.Layers;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxGis.MapsuiModule.Model
{
    public class LayerInfo: BindableBase
    {
        private string _layerName;
        private bool _visibility;
        private double _opacity;

        public ILayer Layer { get; set; }


        public string LayerName 
        {
            get => _layerName;
            set
            {
                _layerName = value;
                RaisePropertyChanged();
            }
        }

        public bool Visibility 
        {
            get => _visibility;
            set
            {
                _visibility = value;
                Layer.Enabled = value;
                RaisePropertyChanged();
            }
        }

        public double Opacity
        {
            get => _opacity;
            set
            {
                _opacity = value;
                Layer.Opacity = value;
                RaisePropertyChanged();
            }
        }


    }
}
