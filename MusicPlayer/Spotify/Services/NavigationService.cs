using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Spotify.Services
{
    public class NavigationService : IDisposable
    {
        private const int MinHistorySize = 256;
        private const int AdditionalHistorySize = 64;
        private readonly NavigationManager _navigationManager;
        private readonly List<string> _history;
        private int _position;
        private bool _isNavigateWithControls;

        public bool CanNavigateBack => _position > 0 && _position < _history.Count;

        public bool CanNavigateForward => _position >= 0 && _position < _history.Count - 1;

        public NavigationService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            _history = new List<string>(MinHistorySize + AdditionalHistorySize)
            {
                _navigationManager.Uri
            };
            _navigationManager.LocationChanged += OnLocationChanged;
        }

        public void NavigateTo(string url)
        {
            _navigationManager.NavigateTo(url);
        }

        public void NavigateBack()
        {
            if (!CanNavigateBack)
            {
                return;
            }
            var url = _history[--_position];
            _isNavigateWithControls = true;
            _navigationManager.NavigateTo(url);
        }

        public void NavigateForward()
        {
            if (!CanNavigateForward)
            {
                return;
            }
            var url = _history[++_position];
            _isNavigateWithControls = true;
            _navigationManager.NavigateTo(url);
        }

        private void OnLocationChanged(object? sender, LocationChangedEventArgs e)
        {
            EnsureSize();
            if (!_isNavigateWithControls)
            {
                if (_position >= 0 && _position < _history.Count && _history[_position] == e.Location)
                {
                    return;
                }

                _history.RemoveRange(_position + 1, _history.Count - _position - 1);
                _history.Add(e.Location);
                _position++;
            }
            _isNavigateWithControls = false;
        }

        private void EnsureSize()
        {
            if (_history.Count < MinHistorySize + AdditionalHistorySize)
            {
                return;
            }
            _history.RemoveRange(0, _history.Count - MinHistorySize);
        }

        public void Dispose()
        {
            _navigationManager.LocationChanged -= OnLocationChanged;
        }
    }
}
